export interface GetColumns
{
    id: number;
    columns: string[];
}

export interface UpdateColumnsRequest
{
    id: number;
    columns: [string, any][];
}