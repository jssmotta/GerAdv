"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import OperadorGrid from "@/app/GerAdv_TS/Operador/Crud/Grids/OperadorGrid";

export class OperadorGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <OperadorGrid />;
    }
}