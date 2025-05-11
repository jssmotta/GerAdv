"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import GUTMatrizGrid from "@/app/GerAdv_TS/GUTMatriz/Crud/Grids/GUTMatrizGrid";

export class GUTMatrizGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <GUTMatrizGrid />;
    }
}