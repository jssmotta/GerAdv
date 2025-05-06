"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import DocumentosGrid from "@/app/GerAdv_TS/Documentos/Crud/Grids/DocumentosGrid";

export class DocumentosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <DocumentosGrid />;
    }
}