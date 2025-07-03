//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { JusticaEmpty } from '../../../Models/Justica';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IJustica } from '../../Interfaces/interface.Justica';
import { JusticaService } from '../../Services/Justica.service';
import { JusticaApi } from '../../Apis/ApiJustica';
import { JusticaGridMobileComponent } from '../GridsMobile/Justica';
import { JusticaGridDesktopComponent } from '../GridsDesktop/Justica';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterJustica } from '../../Filters/Justica';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import JusticaWindow from './JusticaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useJusticaList } from '../../Hooks/hookJustica';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const JusticaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const justicaService = useMemo(() => {
    return new JusticaService(
    new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: justica, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useJusticaList(justicaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedJustica, setSelectedJustica] = useState<IJustica>(JusticaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterJustica | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterJustica | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterJustica);
};
// Handlers para o grid
const handleRowClick = (justica: IJustica) => {
  setSelectedJustica(justica);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedJustica(JusticaEmpty());
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
  const justica = e.dataItem;
  setDeleteId(justica.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await justicaService.deleteJustica(deleteId);
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
    <JusticaGridMobileComponent
    data={justica}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <JusticaGridDesktopComponent
    data={justica}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <JusticaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedJustica={selectedJustica}
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
export default JusticaGrid;