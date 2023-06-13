#This program capture network trafic
import pyshark

def packet_handler(packet):
    # Process the captured packet data here
    with open('output.txt', 'a') as f:
        print(packet, file=f)

# Define the network interface to capture packets from
interface = r'\Device\NPF_Loopback'  

# Create a capture object
capture = pyshark.LiveCapture(interface=interface)

# Set the packet callback
capture.apply_on_packets(packet_handler)

# Start the packet capture
capture.start()
