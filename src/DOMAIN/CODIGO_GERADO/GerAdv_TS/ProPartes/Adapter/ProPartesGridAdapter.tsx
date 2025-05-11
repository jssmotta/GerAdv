"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ProPartesGrid from "@/app/GerAdv_TS/ProPartes/Crud/Grids/ProPartesGrid";

export class ProPartesGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ProPartesGrid />;
    }
}