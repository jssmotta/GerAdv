'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { TribEnderecosGridAdapter } from '@/app/GerAdv_TS/TribEnderecos/Adapter/TribEnderecosGridAdapter';
import TribEnderecosGridContainer from '@/app/GerAdv_TS/TribEnderecos/Components/TribEnderecosGridContainer';
const TribEnderecosPage: React.FC = () => {
  const TribEnderecosGrid = new TribEnderecosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Trib Endereços' />
    <TribEnderecosGridContainer grid={TribEnderecosGrid} />
  </PageLayout>
);
};
export default TribEnderecosPage;