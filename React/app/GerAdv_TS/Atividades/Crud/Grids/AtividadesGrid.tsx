//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AtividadesEmpty } from '../../../Models/Atividades';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAtividades } from '../../Interfaces/interface.Atividades';
import { AtividadesService } from '../../Services/Atividades.service';
import { AtividadesApi } from '../../Apis/ApiAtividades';
import { AtividadesGridMobileComponent } from '../GridsMobile/Atividades';
import { AtividadesGridDesktopComponent } from '../GridsDesktop/Atividades';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAtividades } from '../../Filters/Atividades';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AtividadesWindow from './AtividadesWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAtividadesList } from '../../Hooks/hookAtividades';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AtividadesGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const atividadesService = useMemo(() => {
    return new AtividadesService(
    new AtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: atividades, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAtividadesList(atividadesService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAtividades, setSelectedAtividades] = useState<IAtividades>(AtividadesEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAtividades | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAtividades | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAtividades);
};
// Handlers para o grid
const handleRowClick = (atividades: IAtividades) => {
  setSelectedAtividades(atividades);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAtividades(AtividadesEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const atividades = e.dataItem;
  setDeleteId(atividades.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await atividadesService.deleteAtividades(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <AtividadesGridMobileComponent
    data={atividades}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AtividadesGridDesktopComponent
    data={atividades}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AtividadesWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAtividades={selectedAtividades}
    />

    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default AtividadesGrid;