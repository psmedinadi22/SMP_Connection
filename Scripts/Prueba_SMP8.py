from scapy.all import sniff

def packet_handler(packet):
    # Process the captured packet data here
    print(packet.show())

# Define the network interface to capture packets from
interface = 'eth0'  # Replace 'eth0' with your desired network interface name

# Start capturing packets
sniff(iface=interface, prn=packet_handler)
