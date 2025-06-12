//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { FuncionariosEmpty } from '../../../Models/Funcionarios';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IFuncionarios } from '../../Interfaces/interface.Funcionarios';
import { FuncionariosService } from '../../Services/Funcionarios.service';
import { FuncionariosApi } from '../../Apis/ApiFuncionarios';
import { FuncionariosGridMobileComponent } from '../GridsMobile/Funcionarios';
import { FuncionariosGridDesktopComponent } from '../GridsDesktop/Funcionarios';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterFuncionarios } from '../../Filters/Funcionarios';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import FuncionariosWindow from './FuncionariosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useFuncionariosList } from '../../Hooks/hookFuncionarios';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const FuncionariosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const funcionariosService = useMemo(() => {
    return new FuncionariosService(
    new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: funcionarios, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useFuncionariosList(funcionariosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedFuncionarios, setSelectedFuncionarios] = useState<IFuncionarios>(FuncionariosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterFuncionarios | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterFuncionarios | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterFuncionarios);
};
// Handlers para o grid
const handleRowClick = (funcionarios: IFuncionarios) => {
  setSelectedFuncionarios(funcionarios);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedFuncionarios(FuncionariosEmpty());
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
  const funcionarios = e.dataItem;
  setDeleteId(funcionarios.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await funcionariosService.deleteFuncionarios(deleteId);
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
    <FuncionariosGridMobileComponent
    data={funcionarios}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <FuncionariosGridDesktopComponent
    data={funcionarios}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <FuncionariosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedFuncionarios={selectedFuncionarios}
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
export default FuncionariosGrid;