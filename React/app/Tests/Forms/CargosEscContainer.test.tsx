import React from 'react';
import { render } from '@testing-library/react';
import CargosEscIncContainer from '@/app/GerAdv_TS/CargosEsc/Components/CargosEscIncContainer';
// CargosEscIncContainer.test.tsx
// Mock do CargosEscInc
jest.mock('@/app/GerAdv_TS/CargosEsc/Crud/Inc/CargosEsc', () => (props: any) => (
<div data-testid='cargosesc-inc-mock' {...props} />
));
describe('CargosEscIncContainer', () => {
  it('deve renderizar CargosEscInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <CargosEscIncContainer id={id} navigator={mockNavigator} />
  );
  const cargosescInc = getByTestId('cargosesc-inc-mock');
  expect(cargosescInc).toBeInTheDocument();
  expect(cargosescInc.getAttribute('id')).toBe(id.toString());

});
});