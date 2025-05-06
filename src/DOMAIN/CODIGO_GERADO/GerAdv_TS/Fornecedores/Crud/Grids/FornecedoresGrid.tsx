//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { FornecedoresEmpty } from "../../../Models/Fornecedores";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IFornecedores } from "../../Interfaces/interface.Fornecedores";
import { FornecedoresService } from "../../Services/Fornecedores.service";
import { FornecedoresApi } from "../../Apis/ApiFornecedores";
import { FornecedoresGridMobileComponent } from "../GridsMobile/Fornecedores";
import { FornecedoresGridDesktopComponent } from "../GridsDesktop/Fornecedores";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterFornecedores } from "../../Filters/Fornecedores";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import FornecedoresWindow from "./FornecedoresWindow";

const FornecedoresGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [fornecedores, setFornecedores] = useState<IFornecedores[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedFornecedores, setSelectedFornecedores] = useState<IFornecedores>(FornecedoresEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new FornecedoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterFornecedores | undefined | null>(null);

    const fornecedoresService = useMemo(() => {
      return new FornecedoresService(
          new FornecedoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchFornecedores = async (filtro?: FilterFornecedores | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await fornecedoresService.getList(filtro ?? {} as FilterFornecedores);
        setFornecedores(data);
      }
      else {
        const data = await fornecedoresService.getAll(filtro ?? {} as FilterFornecedores);
        setFornecedores(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchFornecedores(currFilter);
    }, [showInc]);
  
    const handleRowClick = (fornecedores: IFornecedores) => {
      if (isMobile) {
        router.push(`/pages/fornecedores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${fornecedores.id}`);
      } else {
        setSelectedFornecedores(fornecedores);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/fornecedores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedFornecedores(FornecedoresEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchFornecedores(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const fornecedores = e.dataItem;		
        setDeleteId(fornecedores.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchFornecedores(currFilter);
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
           <FornecedoresGridMobileComponent data={fornecedores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <FornecedoresGridDesktopComponent data={fornecedores} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <FornecedoresWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedFornecedores={selectedFornecedores}>       
        </FornecedoresWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default FornecedoresGrid;