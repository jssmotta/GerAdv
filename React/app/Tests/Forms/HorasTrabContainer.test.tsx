import React from 'react';
import { render } from '@testing-library/react';
import HorasTrabIncContainer from '@/app/GerAdv_TS/HorasTrab/Components/HorasTrabIncContainer';
// HorasTrabIncContainer.test.tsx
// Mock do HorasTrabInc
jest.mock('@/app/GerAdv_TS/HorasTrab/Crud/Inc/HorasTrab', () => (props: any) => (
<div data-testid='horastrab-inc-mock' {...props} />
));
describe('HorasTrabIncContainer', () => {
  it('deve renderizar HorasTrabInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <HorasTrabIncContainer id={id} navigator={mockNavigator} />
  );
  const horastrabInc = getByTestId('horastrab-inc-mock');
  expect(horastrabInc).toBeInTheDocument();
  expect(horastrabInc.getAttribute('id')).toBe(id.toString());

});
});