//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { OperadorGruposAgendaEmpty } from "../../../Models/OperadorGruposAgenda";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import OperadorGruposAgendaInc from "../Inc/OperadorGruposAgenda";
import { IOperadorGruposAgenda } from "../../Interfaces/interface.OperadorGruposAgenda";
import { OperadorGruposAgendaService } from "../../Services/OperadorGruposAgenda.service";
import { OperadorGruposAgendaApi } from "../../Apis/ApiOperadorGruposAgenda";
import { OperadorGruposAgendaGridMobileComponent } from "../GridsMobile/OperadorGruposAgenda";
import { OperadorGruposAgendaGridDesktopComponent } from "../GridsDesktop/OperadorGruposAgenda";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterOperadorGruposAgenda } from "../../Filters/OperadorGruposAgenda";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import OperadorGruposAgendaWindow from "./OperadorGruposAgendaWindow";

const OperadorGruposAgendaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [operadorgruposagenda, setOperadorGruposAgenda] = useState<IOperadorGruposAgenda[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedOperadorGruposAgenda, setSelectedOperadorGruposAgenda] = useState<IOperadorGruposAgenda>(OperadorGruposAgendaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterOperadorGruposAgenda | undefined | null>(null);

    const operadorgruposagendaService = useMemo(() => {
      return new OperadorGruposAgendaService(
          new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchOperadorGruposAgenda = async (filtro?: FilterOperadorGruposAgenda | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await operadorgruposagendaService.getList(filtro ?? {} as FilterOperadorGruposAgenda);
        setOperadorGruposAgenda(data);
      }
      else {
        const data = await operadorgruposagendaService.getAll(filtro ?? {} as FilterOperadorGruposAgenda);
        setOperadorGruposAgenda(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchOperadorGruposAgenda(currFilter);
    }, [showInc]);
  
    const handleRowClick = (operadorgruposagenda: IOperadorGruposAgenda) => {
      if (isMobile) {
        router.push(`/pages/operadorgruposagenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${operadorgruposagenda.id}`);
      } else {
        setSelectedOperadorGruposAgenda(operadorgruposagenda);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/operadorgruposagenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedOperadorGruposAgenda(OperadorGruposAgendaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchOperadorGruposAgenda(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const operadorgruposagenda = e.dataItem;		
        setDeleteId(operadorgruposagenda.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchOperadorGruposAgenda(currFilter);
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
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <OperadorGruposAgendaGridMobileComponent data={operadorgruposagenda} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <OperadorGruposAgendaGridDesktopComponent data={operadorgruposagenda} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <OperadorGruposAgendaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedOperadorGruposAgenda={selectedOperadorGruposAgenda}>       
        </OperadorGruposAgendaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default OperadorGruposAgendaGrid;