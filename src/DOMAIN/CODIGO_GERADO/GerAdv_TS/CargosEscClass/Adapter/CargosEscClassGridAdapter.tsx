"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import CargosEscClassGrid from "@/app/GerAdv_TS/CargosEscClass/Crud/Grids/CargosEscClassGrid";

export class CargosEscClassGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <CargosEscClassGrid />;
    }
}