export interface ITicket {
  ticketId: number | null;
  userId: number | null;
  ticketType: number;
  sourceId: number;
  destinationId: number;
  departureDate: Date | null;
  returnDate: Date | null;
  totalPassengers: number | null;
  adult: number | null;
  children: number | null;
  id: number | null;
  sourceName: string | null;
  destinationName: string | null;
  username: string | null; 
  firstName: string | null; 
  lastName: string | null; 
  // Add other properties as needed
}
