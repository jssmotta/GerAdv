import React from 'react';
import { render } from '@testing-library/react';
import GruposEmpresasCliIncContainer from '@/app/GerAdv_TS/GruposEmpresasCli/Components/GruposEmpresasCliIncContainer';
// GruposEmpresasCliIncContainer.test.tsx
// Mock do GruposEmpresasCliInc
jest.mock('@/app/GerAdv_TS/GruposEmpresasCli/Crud/Inc/GruposEmpresasCli', () => (props: any) => (
<div data-testid='gruposempresascli-inc-mock' {...props} />
));
describe('GruposEmpresasCliIncContainer', () => {
  it('deve renderizar GruposEmpresasCliInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <GruposEmpresasCliIncContainer id={id} navigator={mockNavigator} />
  );
  const gruposempresascliInc = getByTestId('gruposempresascli-inc-mock');
  expect(gruposempresascliInc).toBeInTheDocument();
  expect(gruposempresascliInc.getAttribute('id')).toBe(id.toString());

});
});