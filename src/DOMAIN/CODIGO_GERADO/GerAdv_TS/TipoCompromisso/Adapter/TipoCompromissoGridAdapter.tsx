"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import TipoCompromissoGrid from "@/app/GerAdv_TS/TipoCompromisso/Crud/Grids/TipoCompromissoGrid";

export class TipoCompromissoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <TipoCompromissoGrid />;
    }
}