"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import AgendaRecordsGrid from "@/app/GerAdv_TS/AgendaRecords/Crud/Grids/AgendaRecordsGrid";

export class AgendaRecordsGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <AgendaRecordsGrid />;
    }
}