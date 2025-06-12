//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { PrepostosEmpty } from '../../../Models/Prepostos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IPrepostos } from '../../Interfaces/interface.Prepostos';
import { PrepostosService } from '../../Services/Prepostos.service';
import { PrepostosApi } from '../../Apis/ApiPrepostos';
import { PrepostosGridMobileComponent } from '../GridsMobile/Prepostos';
import { PrepostosGridDesktopComponent } from '../GridsDesktop/Prepostos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterPrepostos } from '../../Filters/Prepostos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import PrepostosWindow from './PrepostosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { usePrepostosList } from '../../Hooks/hookPrepostos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const PrepostosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const prepostosService = useMemo(() => {
    return new PrepostosService(
    new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: prepostos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = usePrepostosList(prepostosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedPrepostos, setSelectedPrepostos] = useState<IPrepostos>(PrepostosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterPrepostos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterPrepostos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterPrepostos);
};
// Handlers para o grid
const handleRowClick = (prepostos: IPrepostos) => {
  setSelectedPrepostos(prepostos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedPrepostos(PrepostosEmpty());
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
  const prepostos = e.dataItem;
  setDeleteId(prepostos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await prepostosService.deletePrepostos(deleteId);
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
    <PrepostosGridMobileComponent
    data={prepostos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <PrepostosGridDesktopComponent
    data={prepostos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <PrepostosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedPrepostos={selectedPrepostos}
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
export default PrepostosGrid;