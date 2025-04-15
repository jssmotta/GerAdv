import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import TribEnderecosInc from "../Inc/TribEnderecos";
import { ITribEnderecos } from "../../Interfaces/interface.TribEnderecos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { TribEnderecosEmpty } from "@/app/GerAdv_TS/Models/TribEnderecos";
import { useWindow } from "@/app/hooks/useWindows";

interface TribEnderecosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedTribEnderecos?: ITribEnderecos;
    onSuccess: () => void;
    onError: () => void;
}

const TribEnderecosWindow: React.FC<TribEnderecosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedTribEnderecos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/tribenderecos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedTribEnderecos?.id}`);
        }

    }, [isMobile, router, selectedTribEnderecos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={725}
                    newWidth={720}
                    id={(selectedTribEnderecos?.id ?? 0).toString()}
                >
                    <TribEnderecosInc
                        id={selectedTribEnderecos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowTribEnderecos: React.FC<TribEnderecosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <TribEnderecosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedTribEnderecos={TribEnderecosEmpty()}>
        </TribEnderecosWindow>
    )
};

export default TribEnderecosWindow;