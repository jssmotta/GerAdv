//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { OperadorEmpty } from "../../../Models/Operador";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import OperadorInc from "../Inc/Operador";
import { IOperador } from "../../Interfaces/interface.Operador";
import { OperadorService } from "../../Services/Operador.service";
import { OperadorApi } from "../../Apis/ApiOperador";
import { OperadorGridMobileComponent } from "../GridsMobile/Operador";
import { OperadorGridDesktopComponent } from "../GridsDesktop/Operador";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterOperador } from "../../Filters/Operador";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import OperadorWindow from "./OperadorWindow";

const OperadorGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [operador, setOperador] = useState<IOperador[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedOperador, setSelectedOperador] = useState<IOperador>(OperadorEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterOperador | undefined | null>(null);

    const operadorService = useMemo(() => {
      return new OperadorService(
          new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchOperador = async (filtro?: FilterOperador | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await operadorService.getList(filtro ?? {} as FilterOperador);
        setOperador(data);
      }
      else {
        const data = await operadorService.getAll(filtro ?? {} as FilterOperador);
        setOperador(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchOperador(currFilter);
    }, [showInc]);
  
    const handleRowClick = (operador: IOperador) => {
      if (isMobile) {
        router.push(`/pages/operador/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${operador.id}`);
      } else {
        setSelectedOperador(operador);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/operador/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedOperador(OperadorEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchOperador(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const operador = e.dataItem;		
        setDeleteId(operador.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchOperador(currFilter);
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
           <OperadorGridMobileComponent data={operador} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <OperadorGridDesktopComponent data={operador} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <OperadorWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedOperador={selectedOperador}>       
        </OperadorWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default OperadorGrid;