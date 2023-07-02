
export interface IBooking {
  id: number;
  userId: string;
  ticketType: string;
  sourceId: number;
  destinationId: number;
  departureDate: string;
  returnDate: string;
}
