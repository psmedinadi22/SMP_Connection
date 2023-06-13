import pyshark
import requests

target_ip = '192.168.7.70'  # Replace with the desired IP address
username = 'Administrator'  # Replace with your authentication username
password = 'aasa1234'  # Replace with your authentication password

def packet_handler(pkt):
    # Check if the packet has the desired source IP address
    if 'ip' in pkt and hasattr(pkt.ip, 'src'):
        if pkt.ip.src == target_ip:
            

            # Perform authentication by sending a request with the username and password
            authenticated = authenticate(username, password)
            if authenticated:
                print('Authentication: Successful')
                # Process the packet data here
                print('Packet Data:', pkt.get_raw_packet())
            else:
                print('Authentication: Failed')


            print('Packet Details:')
            print('Source IP:', pkt.ip.src)
            print('Destination IP:', pkt.ip.dst)
            print('Protocol:', pkt.highest_layer)
            print('Timestamp:', pkt.sniff_time)

            print('-' * 50)

# Function to perform authentication
def authenticate(username, password):
    # Define the authentication endpoint URL
    authentication_url = f'http://{target_ip}/authenticate'

    # Create a session object
    session = requests.Session()

    # Send a POST request with the username and password as the payload
    response = session.post(authentication_url, data={'username': username, 'password': password}, timeout=5)

    # Check if the authentication was successful (adjust the response condition as per your API's response)
    if response.status_code == 200 and response.json().get('success'):
        return True
    else:
        return False

# Define the network interface to capture packets from
interface = r'\Device\NPF_{16CF4130-3094-4B74-8B6B-1D68317BBDFB}'

# Create a capture object with raw packet data enabled
capture = pyshark.LiveCapture(interface=interface, use_json=True, include_raw=True)

# Start the packet capture
capture.sniff(timeout=10)  # Capture packets for 10 seconds (adjust as needed)

# Process captured packets
capture.apply_on_packets(packet_handler)


