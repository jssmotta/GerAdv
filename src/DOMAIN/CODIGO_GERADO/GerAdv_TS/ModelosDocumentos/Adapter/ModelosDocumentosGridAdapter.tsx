"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ModelosDocumentosGrid from "@/app/GerAdv_TS/ModelosDocumentos/Crud/Grids/ModelosDocumentosGrid";

export class ModelosDocumentosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ModelosDocumentosGrid />;
    }
}