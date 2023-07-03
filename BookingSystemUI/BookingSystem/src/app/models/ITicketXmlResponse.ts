export interface ITicketXmlResponse{

    TicketId: number | null;
    UserName: string | null;
    Source: string | null;
    Destination: string | null;
    DepartureDate: Date | null;
    TotalPassengers: number | null;
    Adult: number | null;
    Children: number | null;   
}