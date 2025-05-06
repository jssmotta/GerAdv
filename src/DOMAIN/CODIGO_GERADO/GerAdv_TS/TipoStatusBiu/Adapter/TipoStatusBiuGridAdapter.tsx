"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import TipoStatusBiuGrid from "@/app/GerAdv_TS/TipoStatusBiu/Crud/Grids/TipoStatusBiuGrid";

export class TipoStatusBiuGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <TipoStatusBiuGrid />;
    }
}