"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import AgendaGrid from "@/app/GerAdv_TS/Agenda/Crud/Grids/AgendaGrid";

export class AgendaGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <AgendaGrid />;
    }
}