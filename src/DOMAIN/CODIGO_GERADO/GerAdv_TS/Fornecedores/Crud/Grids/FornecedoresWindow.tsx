import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import FornecedoresInc from "../Inc/Fornecedores";
import { IFornecedores } from "../../Interfaces/interface.Fornecedores";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { FornecedoresEmpty } from "@/app/GerAdv_TS/Models/Fornecedores";
import { useWindow } from "@/app/hooks/useWindows";

interface FornecedoresWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedFornecedores?: IFornecedores;
    onSuccess: () => void;
    onError: () => void;
}

const FornecedoresWindow: React.FC<FornecedoresWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedFornecedores,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/fornecedores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedFornecedores?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedFornecedores]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={759}
                    newWidth={1440}
                    id={(selectedFornecedores?.id ?? 0).toString()}
                >
                    <FornecedoresInc
                        id={selectedFornecedores?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowFornecedores: React.FC<FornecedoresWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <FornecedoresWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedFornecedores={FornecedoresEmpty()}>
        </FornecedoresWindow>
    )
};

export default FornecedoresWindow;