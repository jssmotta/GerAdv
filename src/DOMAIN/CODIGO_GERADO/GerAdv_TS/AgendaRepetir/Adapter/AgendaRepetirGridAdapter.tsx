"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import AgendaRepetirGrid from "@/app/GerAdv_TS/AgendaRepetir/Crud/Grids/AgendaRepetirGrid";

export class AgendaRepetirGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <AgendaRepetirGrid />;
    }
}