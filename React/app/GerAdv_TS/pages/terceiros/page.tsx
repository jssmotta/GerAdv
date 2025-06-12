'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { TerceirosGridAdapter } from '@/app/GerAdv_TS/Terceiros/Adapter/TerceirosGridAdapter';
import TerceirosGridContainer from '@/app/GerAdv_TS/Terceiros/Components/TerceirosGridContainer';
const TerceirosPage: React.FC = () => {
  const TerceirosGrid = new TerceirosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Terceiros' />
    <TerceirosGridContainer grid={TerceirosGrid} />
  </PageLayout>
);
};
export default TerceirosPage;