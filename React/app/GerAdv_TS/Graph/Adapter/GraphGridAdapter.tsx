'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import GraphGrid from '@/app/GerAdv_TS/Graph/Crud/Grids/GraphGrid';
export class GraphGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <GraphGrid />;
  }
}