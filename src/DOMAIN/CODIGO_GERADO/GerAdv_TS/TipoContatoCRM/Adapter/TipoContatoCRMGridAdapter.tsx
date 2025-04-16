"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import TipoContatoCRMGrid from "@/app/GerAdv_TS/TipoContatoCRM/Crud/Grids/TipoContatoCRMGrid";

export class TipoContatoCRMGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <TipoContatoCRMGrid />;
    }
}