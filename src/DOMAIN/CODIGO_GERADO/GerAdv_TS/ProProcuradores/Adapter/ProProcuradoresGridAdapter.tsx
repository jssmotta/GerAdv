"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ProProcuradoresGrid from "@/app/GerAdv_TS/ProProcuradores/Crud/Grids/ProProcuradoresGrid";

export class ProProcuradoresGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ProProcuradoresGrid />;
    }
}