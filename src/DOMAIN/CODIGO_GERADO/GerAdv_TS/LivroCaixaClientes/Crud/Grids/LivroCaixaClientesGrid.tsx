//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { LivroCaixaClientesEmpty } from "../../../Models/LivroCaixaClientes";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ILivroCaixaClientes } from "../../Interfaces/interface.LivroCaixaClientes";
import { LivroCaixaClientesService } from "../../Services/LivroCaixaClientes.service";
import { LivroCaixaClientesApi } from "../../Apis/ApiLivroCaixaClientes";
import { LivroCaixaClientesGridMobileComponent } from "../GridsMobile/LivroCaixaClientes";
import { LivroCaixaClientesGridDesktopComponent } from "../GridsDesktop/LivroCaixaClientes";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterLivroCaixaClientes } from "../../Filters/LivroCaixaClientes";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import LivroCaixaClientesWindow from "./LivroCaixaClientesWindow";

const LivroCaixaClientesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [livrocaixaclientes, setLivroCaixaClientes] = useState<ILivroCaixaClientes[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedLivroCaixaClientes, setSelectedLivroCaixaClientes] = useState<ILivroCaixaClientes>(LivroCaixaClientesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new LivroCaixaClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterLivroCaixaClientes | undefined | null>(null);

    const livrocaixaclientesService = useMemo(() => {
      return new LivroCaixaClientesService(
          new LivroCaixaClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchLivroCaixaClientes = async (filtro?: FilterLivroCaixaClientes | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await livrocaixaclientesService.getAll(filtro ?? {} as FilterLivroCaixaClientes);
        setLivroCaixaClientes(data);
      }
      else {
        const data = await livrocaixaclientesService.getAll(filtro ?? {} as FilterLivroCaixaClientes);
        setLivroCaixaClientes(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchLivroCaixaClientes(currFilter);
    }, [showInc]);
  
    const handleRowClick = (livrocaixaclientes: ILivroCaixaClientes) => {
      if (isMobile) {
        router.push(`/pages/livrocaixaclientes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${livrocaixaclientes.id}`);
      } else {
        setSelectedLivroCaixaClientes(livrocaixaclientes);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/livrocaixaclientes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedLivroCaixaClientes(LivroCaixaClientesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchLivroCaixaClientes(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const livrocaixaclientes = e.dataItem;		
        setDeleteId(livrocaixaclientes.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchLivroCaixaClientes(currFilter);
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
           <LivroCaixaClientesGridMobileComponent data={livrocaixaclientes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <LivroCaixaClientesGridDesktopComponent data={livrocaixaclientes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <LivroCaixaClientesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedLivroCaixaClientes={selectedLivroCaixaClientes}>       
        </LivroCaixaClientesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default LivroCaixaClientesGrid;