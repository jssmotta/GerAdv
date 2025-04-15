"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import TipoModeloDocumentoGrid from "@/app/GerAdv_TS/TipoModeloDocumento/Crud/Grids/TipoModeloDocumentoGrid";

export class TipoModeloDocumentoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <TipoModeloDocumentoGrid />;
    }
}