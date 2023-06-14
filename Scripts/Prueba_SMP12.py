#Author: Paula Medina

#This code read the encripted data and packet details
import pyshark

target_ip = '192.168.7.40'  # Replace with the desired IP address

def packet_handler(pkt):
    # Check if the packet has the desired source IP address
    if 'ip' in pkt and hasattr(pkt.ip, 'src'):
        if pkt.ip.src == target_ip:
            print('Packet Details:')
            print('Source IP:', pkt.ip.src)
            print('Destination IP:', pkt.ip.dst)
            print('Protocol:', pkt.highest_layer)
            print('Timestamp:', pkt.sniff_time)
            print('Packet Data:', pkt.get_raw_packet())
            print('-' * 50)

# Define the network interface to capture packets from
interface = r'\Device\NPF_{16CF4130-3094-4B74-8B6B-1D68317BBDFB}'

# Create a capture object with raw packet data enabled
capture = pyshark.LiveCapture(interface=interface, use_json=True, include_raw=True)

# Start the packet capture
capture.sniff(timeout=10)  # Capture packets for 10 seconds (adjust as needed)

# Process captured packets
capture.apply_on_packets(packet_handler)



