//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { GUTPeriodicidadeEmpty } from '../../../Models/GUTPeriodicidade';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IGUTPeriodicidade } from '../../Interfaces/interface.GUTPeriodicidade';
import { GUTPeriodicidadeService } from '../../Services/GUTPeriodicidade.service';
import { GUTPeriodicidadeApi } from '../../Apis/ApiGUTPeriodicidade';
import { GUTPeriodicidadeGridMobileComponent } from '../GridsMobile/GUTPeriodicidade';
import { GUTPeriodicidadeGridDesktopComponent } from '../GridsDesktop/GUTPeriodicidade';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterGUTPeriodicidade } from '../../Filters/GUTPeriodicidade';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import GUTPeriodicidadeWindow from './GUTPeriodicidadeWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useGUTPeriodicidadeList } from '../../Hooks/hookGUTPeriodicidade';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const GUTPeriodicidadeGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const gutperiodicidadeService = useMemo(() => {
    return new GUTPeriodicidadeService(
    new GUTPeriodicidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: gutperiodicidade, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useGUTPeriodicidadeList(gutperiodicidadeService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedGUTPeriodicidade, setSelectedGUTPeriodicidade] = useState<IGUTPeriodicidade>(GUTPeriodicidadeEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterGUTPeriodicidade | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterGUTPeriodicidade | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterGUTPeriodicidade);
};
// Handlers para o grid
const handleRowClick = (gutperiodicidade: IGUTPeriodicidade) => {
  setSelectedGUTPeriodicidade(gutperiodicidade);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedGUTPeriodicidade(GUTPeriodicidadeEmpty());
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
  const gutperiodicidade = e.dataItem;
  setDeleteId(gutperiodicidade.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await gutperiodicidadeService.deleteGUTPeriodicidade(deleteId);
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
    <GUTPeriodicidadeGridMobileComponent
    data={gutperiodicidade}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <GUTPeriodicidadeGridDesktopComponent
    data={gutperiodicidade}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <GUTPeriodicidadeWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedGUTPeriodicidade={selectedGUTPeriodicidade}
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
export default GUTPeriodicidadeGrid;