import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import EnderecosInc from "../Inc/Enderecos";
import { IEnderecos } from "../../Interfaces/interface.Enderecos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { EnderecosEmpty } from "@/app/GerAdv_TS/Models/Enderecos";
import { useWindow } from "@/app/hooks/useWindows";

interface EnderecosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedEnderecos?: IEnderecos;
    onSuccess: () => void;
    onError: () => void;
}

const EnderecosWindow: React.FC<EnderecosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedEnderecos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/enderecos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedEnderecos?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedEnderecos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={732}
                    newWidth={1440}
                    id={(selectedEnderecos?.id ?? 0).toString()}
                >
                    <EnderecosInc
                        id={selectedEnderecos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowEnderecos: React.FC<EnderecosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <EnderecosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedEnderecos={EnderecosEmpty()}>
        </EnderecosWindow>
    )
};

export default EnderecosWindow;