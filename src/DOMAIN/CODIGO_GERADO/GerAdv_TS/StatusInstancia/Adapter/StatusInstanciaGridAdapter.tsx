"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import StatusInstanciaGrid from "@/app/GerAdv_TS/StatusInstancia/Crud/Grids/StatusInstanciaGrid";

export class StatusInstanciaGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <StatusInstanciaGrid />;
    }
}