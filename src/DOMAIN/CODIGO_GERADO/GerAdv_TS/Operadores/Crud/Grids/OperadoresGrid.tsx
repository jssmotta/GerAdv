//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { OperadoresEmpty } from "../../../Models/Operadores";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IOperadores } from "../../Interfaces/interface.Operadores";
import { OperadoresService } from "../../Services/Operadores.service";
import { OperadoresApi } from "../../Apis/ApiOperadores";
import { OperadoresGridMobileComponent } from "../GridsMobile/Operadores";
import { OperadoresGridDesktopComponent } from "../GridsDesktop/Operadores";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterOperadores } from "../../Filters/Operadores";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import OperadoresWindow from "./OperadoresWindow";

const OperadoresGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [operadores, setOperadores] = useState<IOperadores[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedOperadores, setSelectedOperadores] = useState<IOperadores>(OperadoresEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new OperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterOperadores | undefined | null>(null);

    const operadoresService = useMemo(() => {
      return new OperadoresService(
          new OperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchOperadores = async (filtro?: FilterOperadores | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await operadoresService.getList(filtro ?? {} as FilterOperadores);
        setOperadores(data);
      }
      else {
        const data = await operadoresService.getAll(filtro ?? {} as FilterOperadores);
        setOperadores(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchOperadores(currFilter);
    }, [showInc]);
  
    const handleRowClick = (operadores: IOperadores) => {
      if (isMobile) {
        router.push(`/pages/operadores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${operadores.id}`);
      } else {
        setSelectedOperadores(operadores);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/operadores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedOperadores(OperadoresEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchOperadores(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const operadores = e.dataItem;		
        setDeleteId(operadores.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchOperadores(currFilter);
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
           <OperadoresGridMobileComponent data={operadores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <OperadoresGridDesktopComponent data={operadores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <OperadoresWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedOperadores={selectedOperadores}>       
        </OperadoresWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default OperadoresGrid;