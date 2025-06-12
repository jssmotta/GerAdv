//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { NENotasEmpty } from '../../../Models/NENotas';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { INENotas } from '../../Interfaces/interface.NENotas';
import { NENotasService } from '../../Services/NENotas.service';
import { NENotasApi } from '../../Apis/ApiNENotas';
import { NENotasGridMobileComponent } from '../GridsMobile/NENotas';
import { NENotasGridDesktopComponent } from '../GridsDesktop/NENotas';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterNENotas } from '../../Filters/NENotas';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import NENotasWindow from './NENotasWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useNENotasList } from '../../Hooks/hookNENotas';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const NENotasGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const nenotasService = useMemo(() => {
    return new NENotasService(
    new NENotasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: nenotas, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useNENotasList(nenotasService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedNENotas, setSelectedNENotas] = useState<INENotas>(NENotasEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterNENotas | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterNENotas | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterNENotas);
};
// Handlers para o grid
const handleRowClick = (nenotas: INENotas) => {
  setSelectedNENotas(nenotas);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedNENotas(NENotasEmpty());
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
  const nenotas = e.dataItem;
  setDeleteId(nenotas.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await nenotasService.deleteNENotas(deleteId);
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
    <NENotasGridMobileComponent
    data={nenotas}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <NENotasGridDesktopComponent
    data={nenotas}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <NENotasWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedNENotas={selectedNENotas}
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
export default NENotasGrid;