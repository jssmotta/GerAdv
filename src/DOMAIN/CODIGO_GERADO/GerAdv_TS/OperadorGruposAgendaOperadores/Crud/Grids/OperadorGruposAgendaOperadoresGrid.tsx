//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { OperadorGruposAgendaOperadoresEmpty } from "../../../Models/OperadorGruposAgendaOperadores";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IOperadorGruposAgendaOperadores } from "../../Interfaces/interface.OperadorGruposAgendaOperadores";
import { OperadorGruposAgendaOperadoresService } from "../../Services/OperadorGruposAgendaOperadores.service";
import { OperadorGruposAgendaOperadoresApi } from "../../Apis/ApiOperadorGruposAgendaOperadores";
import { OperadorGruposAgendaOperadoresGridMobileComponent } from "../GridsMobile/OperadorGruposAgendaOperadores";
import { OperadorGruposAgendaOperadoresGridDesktopComponent } from "../GridsDesktop/OperadorGruposAgendaOperadores";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterOperadorGruposAgendaOperadores } from "../../Filters/OperadorGruposAgendaOperadores";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import OperadorGruposAgendaOperadoresWindow from "./OperadorGruposAgendaOperadoresWindow";

const OperadorGruposAgendaOperadoresGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [operadorgruposagendaoperadores, setOperadorGruposAgendaOperadores] = useState<IOperadorGruposAgendaOperadores[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedOperadorGruposAgendaOperadores, setSelectedOperadorGruposAgendaOperadores] = useState<IOperadorGruposAgendaOperadores>(OperadorGruposAgendaOperadoresEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new OperadorGruposAgendaOperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterOperadorGruposAgendaOperadores | undefined | null>(null);

    const operadorgruposagendaoperadoresService = useMemo(() => {
      return new OperadorGruposAgendaOperadoresService(
          new OperadorGruposAgendaOperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchOperadorGruposAgendaOperadores = async (filtro?: FilterOperadorGruposAgendaOperadores | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await operadorgruposagendaoperadoresService.getAll(filtro ?? {} as FilterOperadorGruposAgendaOperadores);
        setOperadorGruposAgendaOperadores(data);
      }
      else {
        const data = await operadorgruposagendaoperadoresService.getAll(filtro ?? {} as FilterOperadorGruposAgendaOperadores);
        setOperadorGruposAgendaOperadores(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchOperadorGruposAgendaOperadores(currFilter);
    }, [showInc]);
  
    const handleRowClick = (operadorgruposagendaoperadores: IOperadorGruposAgendaOperadores) => {
      if (isMobile) {
        router.push(`/pages/operadorgruposagendaoperadores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${operadorgruposagendaoperadores.id}`);
      } else {
        setSelectedOperadorGruposAgendaOperadores(operadorgruposagendaoperadores);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/operadorgruposagendaoperadores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedOperadorGruposAgendaOperadores(OperadorGruposAgendaOperadoresEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchOperadorGruposAgendaOperadores(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const operadorgruposagendaoperadores = e.dataItem;		
        setDeleteId(operadorgruposagendaoperadores.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchOperadorGruposAgendaOperadores(currFilter);
            } catch {
            // falta uma mensagem de erro
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

    return (
      <>
            
        {isMobile ?
           <OperadorGruposAgendaOperadoresGridMobileComponent data={operadorgruposagendaoperadores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <OperadorGruposAgendaOperadoresGridDesktopComponent data={operadorgruposagendaoperadores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <OperadorGruposAgendaOperadoresWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedOperadorGruposAgendaOperadores={selectedOperadorGruposAgendaOperadores}>       
        </OperadorGruposAgendaOperadoresWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default OperadorGruposAgendaOperadoresGrid;