export interface ITicket {
  ticketId: number | null;
  userId: number | null;
  ticketType: number;
  source: string;
  destination: string;
  departureDate: Date | null;
  returnDate: Date | null;
  // Add other properties as needed
}
