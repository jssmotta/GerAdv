'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { GUTPeriodicidadeGridAdapter } from '@/app/GerAdv_TS/GUTPeriodicidade/Adapter/GUTPeriodicidadeGridAdapter';
import GUTPeriodicidadeGridContainer from '@/app/GerAdv_TS/GUTPeriodicidade/Components/GUTPeriodicidadeGridContainer';
const GUTPeriodicidadePage: React.FC = () => {
  const GUTPeriodicidadeGrid = new GUTPeriodicidadeGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='G U T Periodicidade' />
    <GUTPeriodicidadeGridContainer grid={GUTPeriodicidadeGrid} />
  </PageLayout>
);
};
export default GUTPeriodicidadePage;