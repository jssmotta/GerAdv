//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { PontoVirtualAcessosEmpty } from '../../../Models/PontoVirtualAcessos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IPontoVirtualAcessos } from '../../Interfaces/interface.PontoVirtualAcessos';
import { PontoVirtualAcessosService } from '../../Services/PontoVirtualAcessos.service';
import { PontoVirtualAcessosApi } from '../../Apis/ApiPontoVirtualAcessos';
import { PontoVirtualAcessosGridMobileComponent } from '../GridsMobile/PontoVirtualAcessos';
import { PontoVirtualAcessosGridDesktopComponent } from '../GridsDesktop/PontoVirtualAcessos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterPontoVirtualAcessos } from '../../Filters/PontoVirtualAcessos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import PontoVirtualAcessosWindow from './PontoVirtualAcessosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { usePontoVirtualAcessosList } from '../../Hooks/hookPontoVirtualAcessos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const PontoVirtualAcessosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const pontovirtualacessosService = useMemo(() => {
    return new PontoVirtualAcessosService(
    new PontoVirtualAcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: pontovirtualacessos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = usePontoVirtualAcessosList(pontovirtualacessosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedPontoVirtualAcessos, setSelectedPontoVirtualAcessos] = useState<IPontoVirtualAcessos>(PontoVirtualAcessosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterPontoVirtualAcessos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterPontoVirtualAcessos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterPontoVirtualAcessos);
};
// Handlers para o grid
const handleRowClick = (pontovirtualacessos: IPontoVirtualAcessos) => {
  setSelectedPontoVirtualAcessos(pontovirtualacessos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedPontoVirtualAcessos(PontoVirtualAcessosEmpty());
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
  const pontovirtualacessos = e.dataItem;
  setDeleteId(pontovirtualacessos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await pontovirtualacessosService.deletePontoVirtualAcessos(deleteId);
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
    <PontoVirtualAcessosGridMobileComponent
    data={pontovirtualacessos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <PontoVirtualAcessosGridDesktopComponent
    data={pontovirtualacessos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <PontoVirtualAcessosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedPontoVirtualAcessos={selectedPontoVirtualAcessos}
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
export default PontoVirtualAcessosGrid;