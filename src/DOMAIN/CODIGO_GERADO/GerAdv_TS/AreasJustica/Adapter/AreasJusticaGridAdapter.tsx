'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AreasJusticaGrid from '@/app/GerAdv_TS/AreasJustica/Crud/Grids/AreasJusticaGrid';
export class AreasJusticaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AreasJusticaGrid />;
  }
}