'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import NEPalavrasChavesGrid from '@/app/GerAdv_TS/NEPalavrasChaves/Crud/Grids/NEPalavrasChavesGrid';
export class NEPalavrasChavesGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <NEPalavrasChavesGrid />;
  }
}