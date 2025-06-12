'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { PenhoraGridAdapter } from '@/app/GerAdv_TS/Penhora/Adapter/PenhoraGridAdapter';
import PenhoraGridContainer from '@/app/GerAdv_TS/Penhora/Components/PenhoraGridContainer';
const PenhoraPage: React.FC = () => {
  const PenhoraGrid = new PenhoraGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Penhora' />
    <PenhoraGridContainer grid={PenhoraGrid} />
  </PageLayout>
);
};
export default PenhoraPage;