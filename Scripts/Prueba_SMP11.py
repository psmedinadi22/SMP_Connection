#This code  read the data from a specific SMP IP
import pyshark

# Define the specific IP address you want to capture packets for
target_ip = '192.168.7.70'  # Replace with the desired IP address

def packet_handler(pkt):
    # Check if the packet has the desired source or destination IP address
    if 'ip' in pkt and hasattr(pkt.ip, 'src') and hasattr(pkt.ip, 'dst'):
        if pkt.ip.src == target_ip or pkt.ip.dst == target_ip:
         #   print('ALL ALRIGHT')
            print(pkt)
            print('-' * 50)
  #      else:
            #print('NOT ALRIGHT')
  #  else:
        #print('NOT ALRIGHT')


# Define the network interface to capture packets from
interface = r'\Device\NPF_{16CF4130-3094-4B74-8B6B-1D68317BBDFB}' 

# Create a capture object
capture = pyshark.LiveCapture(interface=interface)

# Start the packet capture
capture.sniff(timeout=10)  # Capture packets for 10 seconds (adjust as needed)

# Process captured packets
capture.apply_on_packets(packet_handler)

