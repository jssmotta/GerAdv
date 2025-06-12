'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { OperadorGruposAgendaOperadoresGridAdapter } from '@/app/GerAdv_TS/OperadorGruposAgendaOperadores/Adapter/OperadorGruposAgendaOperadoresGridAdapter';
import OperadorGruposAgendaOperadoresGridContainer from '@/app/GerAdv_TS/OperadorGruposAgendaOperadores/Components/OperadorGruposAgendaOperadoresGridContainer';
const OperadorGruposAgendaOperadoresPage: React.FC = () => {
  const OperadorGruposAgendaOperadoresGrid = new OperadorGruposAgendaOperadoresGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Operador Grupos Agenda Operadores' />
    <OperadorGruposAgendaOperadoresGridContainer grid={OperadorGruposAgendaOperadoresGrid} />
  </PageLayout>
);
};
export default OperadorGruposAgendaOperadoresPage;