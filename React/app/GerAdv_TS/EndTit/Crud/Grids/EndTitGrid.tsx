//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { EndTitEmpty } from '../../../Models/EndTit';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IEndTit } from '../../Interfaces/interface.EndTit';
import { EndTitService } from '../../Services/EndTit.service';
import { EndTitApi } from '../../Apis/ApiEndTit';
import { EndTitGridMobileComponent } from '../GridsMobile/EndTit';
import { EndTitGridDesktopComponent } from '../GridsDesktop/EndTit';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterEndTit } from '../../Filters/EndTit';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import EndTitWindow from './EndTitWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useEndTitList } from '../../Hooks/hookEndTit';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const EndTitGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const endtitService = useMemo(() => {
    return new EndTitService(
    new EndTitApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: endtit, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useEndTitList(endtitService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedEndTit, setSelectedEndTit] = useState<IEndTit>(EndTitEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterEndTit | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterEndTit | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterEndTit);
};
// Handlers para o grid
const handleRowClick = (endtit: IEndTit) => {
  setSelectedEndTit(endtit);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedEndTit(EndTitEmpty());
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
  const endtit = e.dataItem;
  setDeleteId(endtit.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await endtitService.deleteEndTit(deleteId);
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
    <EndTitGridMobileComponent
    data={endtit}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <EndTitGridDesktopComponent
    data={endtit}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <EndTitWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedEndTit={selectedEndTit}
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
export default EndTitGrid;