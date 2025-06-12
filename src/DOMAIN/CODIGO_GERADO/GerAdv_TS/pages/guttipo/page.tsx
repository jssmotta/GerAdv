'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { GUTTipoGridAdapter } from '@/app/GerAdv_TS/GUTTipo/Adapter/GUTTipoGridAdapter';
import GUTTipoGridContainer from '@/app/GerAdv_TS/GUTTipo/Components/GUTTipoGridContainer';
const GUTTipoPage: React.FC = () => {
  const GUTTipoGrid = new GUTTipoGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='G U T Tipo' />
    <GUTTipoGridContainer grid={GUTTipoGrid} />
  </PageLayout>
);
};
export default GUTTipoPage;