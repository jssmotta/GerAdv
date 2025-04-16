"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import CargosEscGrid from "@/app/GerAdv_TS/CargosEsc/Crud/Grids/CargosEscGrid";

export class CargosEscGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <CargosEscGrid />;
    }
}