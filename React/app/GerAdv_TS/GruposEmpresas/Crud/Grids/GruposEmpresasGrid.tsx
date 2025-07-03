//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { GruposEmpresasEmpty } from '../../../Models/GruposEmpresas';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IGruposEmpresas } from '../../Interfaces/interface.GruposEmpresas';
import { GruposEmpresasService } from '../../Services/GruposEmpresas.service';
import { GruposEmpresasApi } from '../../Apis/ApiGruposEmpresas';
import { GruposEmpresasGridMobileComponent } from '../GridsMobile/GruposEmpresas';
import { GruposEmpresasGridDesktopComponent } from '../GridsDesktop/GruposEmpresas';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterGruposEmpresas } from '../../Filters/GruposEmpresas';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import GruposEmpresasWindow from './GruposEmpresasWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useGruposEmpresasList } from '../../Hooks/hookGruposEmpresas';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const GruposEmpresasGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const gruposempresasService = useMemo(() => {
    return new GruposEmpresasService(
    new GruposEmpresasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: gruposempresas, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useGruposEmpresasList(gruposempresasService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedGruposEmpresas, setSelectedGruposEmpresas] = useState<IGruposEmpresas>(GruposEmpresasEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterGruposEmpresas | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterGruposEmpresas | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterGruposEmpresas);
};
// Handlers para o grid
const handleRowClick = (gruposempresas: IGruposEmpresas) => {
  setSelectedGruposEmpresas(gruposempresas);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedGruposEmpresas(GruposEmpresasEmpty());
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
  const gruposempresas = e.dataItem;
  setDeleteId(gruposempresas.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await gruposempresasService.deleteGruposEmpresas(deleteId);
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
    <GruposEmpresasGridMobileComponent
    data={gruposempresas}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <GruposEmpresasGridDesktopComponent
    data={gruposempresas}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <GruposEmpresasWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedGruposEmpresas={selectedGruposEmpresas}
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
export default GruposEmpresasGrid;