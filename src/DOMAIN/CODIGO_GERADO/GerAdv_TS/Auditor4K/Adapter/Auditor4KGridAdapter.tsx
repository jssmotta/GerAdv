"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import Auditor4KGrid from "@/app/GerAdv_TS/Auditor4K/Crud/Grids/Auditor4KGrid";

export class Auditor4KGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <Auditor4KGrid />;
    }
}