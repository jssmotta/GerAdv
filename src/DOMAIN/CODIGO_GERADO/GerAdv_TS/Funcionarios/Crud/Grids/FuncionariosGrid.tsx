//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { FuncionariosEmpty } from "../../../Models/Funcionarios";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IFuncionarios } from "../../Interfaces/interface.Funcionarios";
import { FuncionariosService } from "../../Services/Funcionarios.service";
import { FuncionariosApi } from "../../Apis/ApiFuncionarios";
import { FuncionariosGridMobileComponent } from "../GridsMobile/Funcionarios";
import { FuncionariosGridDesktopComponent } from "../GridsDesktop/Funcionarios";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterFuncionarios } from "../../Filters/Funcionarios";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import FuncionariosWindow from "./FuncionariosWindow";

const FuncionariosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [funcionarios, setFuncionarios] = useState<IFuncionarios[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedFuncionarios, setSelectedFuncionarios] = useState<IFuncionarios>(FuncionariosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterFuncionarios | undefined | null>(null);

    const funcionariosService = useMemo(() => {
      return new FuncionariosService(
          new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchFuncionarios = async (filtro?: FilterFuncionarios | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await funcionariosService.getList(filtro ?? {} as FilterFuncionarios);
        setFuncionarios(data);
      }
      else {
        const data = await funcionariosService.getAll(filtro ?? {} as FilterFuncionarios);
        setFuncionarios(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchFuncionarios(currFilter);
    }, [showInc]);
  
    const handleRowClick = (funcionarios: IFuncionarios) => {
      if (isMobile) {
        router.push(`/pages/funcionarios/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${funcionarios.id}`);
      } else {
        setSelectedFuncionarios(funcionarios);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/funcionarios/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedFuncionarios(FuncionariosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchFuncionarios(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const funcionarios = e.dataItem;		
        setDeleteId(funcionarios.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchFuncionarios(currFilter);
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
           <FuncionariosGridMobileComponent data={funcionarios} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <FuncionariosGridDesktopComponent data={funcionarios} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <FuncionariosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedFuncionarios={selectedFuncionarios}>       
        </FuncionariosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default FuncionariosGrid;